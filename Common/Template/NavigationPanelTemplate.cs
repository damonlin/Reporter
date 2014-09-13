using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace Common.Template
{
    public partial class NavigationPanelTemplate : UserControl
    {
        private Stack<FunctionTemplate> subNavigationFuncArrayList = new Stack<FunctionTemplate>();
        private FunctionTemplate nowFunction = new FunctionTemplate();
        private Dictionary<CheckBox, Panel> ParentArrayList = new Dictionary<CheckBox, Panel>();

        public NavigationPanelTemplate()
        {
            InitializeComponent();
        }

        private void InitControl()
        {
            bool bAddParentCheckBox = true;
            Panel ContentPanel = new Panel();
            
            foreach (FunctionTemplate unit in subNavigationFuncArrayList)
            {
                bAddParentCheckBox = true;

                unit.Control.Dock = System.Windows.Forms.DockStyle.Fill;
                unit.Control.Location = new System.Drawing.Point(0, 0);
                unit.Control.Name = "Template" + ((FunctionTemplate)unit).Control.ToString();
                unit.Control.Visible = false;

                subNavigationPanel.Controls.Add(unit.Control);

                // 檢查Parent Node名稱是否重複
                foreach (CheckBox obj in ParentArrayList.Keys)
                {
                    if (obj.Text.Equals(((FunctionTemplate)unit).FuncType[Thread.CurrentThread.CurrentUICulture]) == true)
                    {
                        bAddParentCheckBox = false;
                        ContentPanel = ParentArrayList[obj];
                        break;
                    }
                }

                if (bAddParentCheckBox == true)
                {
                    CheckBox newParentCheckBox = new CheckBox();

                    newParentCheckBox.Dock = DockStyle.Top;
                    newParentCheckBox.Appearance = Appearance.Button;
                    newParentCheckBox.TextAlign = ContentAlignment.MiddleCenter;
                    newParentCheckBox.Text = ((FunctionTemplate)unit).FuncType[Thread.CurrentThread.CurrentUICulture];
                    newParentCheckBox.TextAlign = ContentAlignment.MiddleLeft;
                    newParentCheckBox.Font = new Font("Arial", 9.75f, FontStyle.Bold);
                    newParentCheckBox.ImageList = imageList1;
                    newParentCheckBox.ImageKey = newParentCheckBox.Checked.ToString();
                    newParentCheckBox.ImageAlign = ContentAlignment.MiddleRight;
                    newParentCheckBox.FlatStyle = FlatStyle.Flat;
                    newParentCheckBox.BackColor = Color.White;
                    newParentCheckBox.Height = 40;
                    newParentCheckBox.CheckStateChanged += new EventHandler(newParentCheckBox_CheckStateChanged);
                    
                    ContentPanel = new Panel();
                    ContentPanel.Dock = DockStyle.Top;
                    ContentPanel.Height = 0;

                    panel1.Controls.Add(ContentPanel);
                    panel1.Controls.Add(newParentCheckBox);
                    ParentArrayList.Add(newParentCheckBox, ContentPanel);
                }

                RadioButton newFuncRadioButton = new RadioButton();

                newFuncRadioButton.Appearance = Appearance.Button;
                newFuncRadioButton.FlatStyle = FlatStyle.Flat;
                newFuncRadioButton.TextAlign = ContentAlignment.MiddleCenter;
                newFuncRadioButton.Dock = DockStyle.Top;
                newFuncRadioButton.Text = ((FunctionTemplate)unit).FuncName[Thread.CurrentThread.CurrentUICulture];
                newFuncRadioButton.Font = new Font("Arial", 9.75f, FontStyle.Bold);
                newFuncRadioButton.BackColor = Color.Gray;
                newFuncRadioButton.FlatAppearance.CheckedBackColor = Color.HotPink;
                newFuncRadioButton.FlatAppearance.MouseOverBackColor = Color.HotPink;
                newFuncRadioButton.Height = 40;
                newFuncRadioButton.Click += new EventHandler(newFuncButton_Click);
                ContentPanel.Controls.Add(newFuncRadioButton);
            }
            
        }

        void newFuncButton_Click(object sender, EventArgs e)
        {
            navigationLabel.Text = "  " + ((RadioButton)sender).Text;
            // 顯示對應的畫面
            foreach (Object unit in subNavigationFuncArrayList)
            {
                ((FunctionTemplate)unit).Control.Visible = ((FunctionTemplate)unit).FuncName[Thread.CurrentThread.CurrentUICulture] == ((RadioButton)sender).Text ? true : false;
                if (((FunctionTemplate)unit).Control.Visible)
                {
                    nowFunction = (FunctionTemplate)unit;
                    ((FunctionTemplate)unit).Control.Focus();
                }
            }

            foreach (Panel tmpContentPanel in ParentArrayList.Values)
            {
                if (tmpContentPanel.Controls.Contains((RadioButton)sender) != true)
                {
                    foreach (RadioButton tmpFuncButton in tmpContentPanel.Controls)
                    {
                        tmpFuncButton.Checked = false;
                    }
                }
            }
        }

        void newParentCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            ((CheckBox)sender).ImageKey = ((CheckBox)sender).Checked.ToString();
            ParentArrayList[(CheckBox)sender].Height = ((CheckBox)sender).Checked ? ParentArrayList[(CheckBox)sender].Controls.Count * 40 : 0;
            ParentArrayList[(CheckBox)sender].Select();
        }

        public bool AddFunction(FunctionTemplate func)
        {
            // 檢查功能名稱是否重複
            foreach (Object unit in subNavigationFuncArrayList)
            {
                if (((FunctionTemplate)unit).FuncType[Thread.CurrentThread.CurrentUICulture].Equals(func.FuncType[Thread.CurrentThread.CurrentUICulture]) == true && ((FunctionTemplate)unit).FuncName[Thread.CurrentThread.CurrentUICulture].Equals(func.FuncName[Thread.CurrentThread.CurrentUICulture]) == true)
                {
                    MessageBox.Show("[Duplicated Function Type] " + func.FuncType[Thread.CurrentThread.CurrentUICulture] + "!!\n" + "[Duplicated Function Name] " + func.FuncName[Thread.CurrentThread.CurrentUICulture] + "!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            subNavigationFuncArrayList.Push(func);
            return true;
        }

        public void InitNavigationPanel()
        {
            InitControl();
        }

        public Stack<FunctionTemplate> AllFunction
        {
            get { return subNavigationFuncArrayList; }
        }

        public FunctionTemplate NowGunction
        {
            get { return nowFunction; }
        }
    }

    public class FunctionTemplate : Object
    {
        public Dictionary<CultureInfo, string> FuncType = new Dictionary<CultureInfo, string>();
        public Dictionary<CultureInfo, string> FuncName = new Dictionary<CultureInfo, string>();
        public UserControl control = new UserControl();

        public FunctionTemplate()
        {

        }

        public FunctionTemplate(string strFuncType, string strFuncName, UserControl control)
        {
            FuncType.Add(Thread.CurrentThread.CurrentUICulture, strFuncType);
            FuncName.Add(Thread.CurrentThread.CurrentUICulture, strFuncName);
            Control = control;
        }

        public FunctionTemplate(CultureInfo objCultureInfo1, string strFuncType1, string strFuncName1, CultureInfo objCultureInfo2, string strFuncType2, string strFuncName2, UserControl control)
        {
            if (objCultureInfo1.EnglishName != objCultureInfo2.EnglishName)
            {
                FuncType.Add(objCultureInfo1, strFuncType1);
                FuncName.Add(objCultureInfo1, strFuncName1);
                FuncType.Add(objCultureInfo2, strFuncType2);
                FuncName.Add(objCultureInfo2, strFuncName2);
                Control = control;
            }
        }

        public UserControl Control
        {
            get { return control; }
            set { control = value; }
        }
    }
}
