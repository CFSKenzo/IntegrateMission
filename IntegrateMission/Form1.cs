using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrateMission
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DataGridView_ModelList.ColumnHeadersVisible = true;
            DataGridView_ModelList.Columns.Add("ProductName", "Product Name");
            DataGridView_ModelList.Columns.Add("ProductID", "Product ID");
            DataGridView_ModelList.Columns.Add("ModelName", "Model Name");
            DataGridView_ModelList.Columns.Add("Order", "Order");
        }

        private void Button_MissionPathBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog t_FolderBrowserDialog = new FolderBrowserDialog();
            DialogResult t_Result = t_FolderBrowserDialog.ShowDialog();
            if (t_Result == DialogResult.Cancel || string.IsNullOrWhiteSpace(t_FolderBrowserDialog.SelectedPath) == true)
            {
                MessageBox.Show("Please Browser a correct folder or modify Mission path directly");
                return;
            }
            TextBox_MissionPath.Text = t_FolderBrowserDialog.SelectedPath;
        }

        private void Button_StartAnalysis_Click(object sender, EventArgs e)
        {
            string[] t_MissionList = System.IO.Directory.GetDirectories(TextBox_MissionPath.Text);
            if (t_MissionList.Length >= 0)
            {
                foreach (string t_Mission in t_MissionList)
                {
                    ListBox_MissionList.Items.Add(System.IO.Path.GetFileName(t_Mission));
                }
            }
            else
            {
                MessageBox.Show($"Please check path of {TextBox_MissionPath} whether is correct or not!");
            }
        }


        string m_MissionManagerPath = string.Empty;
        List<string> m_IgnoreFolders = new List<string>();

        private void ListBox_MissionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_IgnoreFolders.Clear();
            string t_CurrentProduct = this.ListBox_MissionList.SelectedItem.ToString();

            string t_ModelPath = System.IO.Path.Combine(TextBox_MissionPath.Text, t_CurrentProduct);

            m_MissionManagerPath = System.IO.Path.Combine(t_ModelPath, "MissionManager.ini");

            string[] MissionManageContent = System.IO.File.ReadAllLines(m_MissionManagerPath);

            string[] t_ModelList = System.IO.Directory.GetDirectories(t_ModelPath);

            string t_IgnoreFolderFilePath = System.IO.Path.Combine(t_ModelPath, "IgnoreFolder.txt");
            if (System.IO.File.Exists(t_IgnoreFolderFilePath) == false)
            {
                System.IO.File.Create(t_IgnoreFolderFilePath).Close();
            }
            m_IgnoreFolders.AddRange(System.IO.File.ReadAllLines(System.IO.Path.Combine(t_ModelPath, "IgnoreFolder.txt")));
            foreach (string t_Model in t_ModelList)
            {
                bool t_IsSkip = false;
                ReadMissionManagerFile();
                foreach (string t_IgnoreFolder in m_IgnoreFolders)
                {
                    if (t_Model.CompareTo(t_IgnoreFolder) == 0)
                    {
                        t_IsSkip = true;
                    }
                }
                if (t_IsSkip == false)
                {

                }
            }
        }
        class MissionManagerStruct
        {
            public int s_ProductNum;
            private List<ProductStruct> s_ProductStruct;
            public void AddProductStruct(ProductStruct f_ProductStruct)
            {
                if (s_ProductStruct == null)
                {
                    s_ProductStruct = new List<ProductStruct>();
                }
                s_ProductStruct.Add(f_ProductStruct);
            }
            public List<ProductStruct> GetProductStruct()
            {
                return s_ProductStruct;
            }
            public void SetProductStruct(List<ProductStruct> f_ProductStruct)
            {
                s_ProductStruct = f_ProductStruct;
            }

        }
        class ProductStruct
        {
            public List<string> s_ProductListString;
            public int s_ProductID;
            public string s_ProductName;
            public int s_TypeNum;
            private List<ModelStruct> s_ModelStruct;
            public void ProductStructInput(int f_ProductID, string f_ProductName, int f_TypeNum)
            {
                s_ProductID = f_ProductID;
                s_ProductName = f_ProductName;
                s_TypeNum = f_TypeNum;
            }
            public void AddModelStruct(ModelStruct f_ModelStruct)
            {
                if (s_ModelStruct == null)
                {
                    s_ModelStruct = new List<ModelStruct>();
                }
                s_ModelStruct.Add(f_ModelStruct);
            }
            public List<ModelStruct> GetModelStruct()
            {
                return s_ModelStruct;
            }
        }
        class ModelStruct
        {
            public int s_ModelID;
            public string s_TypeName;
            public int s_Width;
            public int s_Height;
            public int s_Thick;
            public int s_ColorNum;
            public List<ColorStruct> s_ColorStruct;

            public ModelStruct(int f_ModelID, string f_TypeName, int f_Width, int f_Height,  int f_Think, int f_ColorNum)
            {
                s_ModelID = f_ModelID;
                s_TypeName = f_TypeName;
                s_Width = f_Width;
                s_Height = f_Height;
                s_Thick = f_Think;
                s_ColorNum = f_ColorNum;
                
            }
            public void AddColorStruct(ColorStruct f_ColorStruct)
            {
                if(s_ColorStruct == null)
                {
                    s_ColorStruct = new List<ColorStruct>();
                }
                s_ColorStruct.Add(f_ColorStruct);
            }
        }
        class ColorStruct
        {
            public int s_ColorNoID;
            public string s_ColorNoName;
            public bool s_ColorBGTwice;
            public ColorStruct(int f_ColorNoID, string f_ColorNoName, bool f_ColorBGTwice)
            {
                s_ColorNoID = f_ColorNoID;
                s_ColorNoName = f_ColorNoName;
                s_ColorBGTwice = f_ColorBGTwice;
            }
        }

        private MissionManagerStruct m_MissionManagerStruct = null;
        private MissionManagerStruct ReadMissionManagerFile()
        {
            List<string> t_MissionManagerContents = new List<string>(System.IO.File.ReadAllLines(m_MissionManagerPath));
            //Check and remove empty line
            bool t_NeedCheckEmpty = true;
            while(t_NeedCheckEmpty == true)
            {
                t_NeedCheckEmpty = false;
                for (int i = 0; i < t_MissionManagerContents.Count; i++)
                {
                    if (string.IsNullOrEmpty(t_MissionManagerContents[i]) || string.IsNullOrWhiteSpace(t_MissionManagerContents[i]))
                    {
                        t_MissionManagerContents.RemoveAt(i);
                        t_NeedCheckEmpty = true;
                        break;
                    }
                }
            }

            m_MissionManagerStruct = new MissionManagerStruct();
            //Divide product
            System.Text.RegularExpressions.Regex t_Regex = new System.Text.RegularExpressions.Regex("^\\[Product(\\d*)\\]$");
            System.Text.RegularExpressions.Match t_Match = null;

            ProductStruct t_ProductStruct = default;
            List<ProductStruct> t_ProductStructList = new List<ProductStruct>();
            for (int i = 0; i < t_MissionManagerContents.Count; i++)
            {
                t_Match = t_Regex.Match(t_MissionManagerContents[i]);
                if(t_Match.Success == true)
                {
                    t_ProductStruct = new ProductStruct();
                    t_ProductStruct.s_ProductListString = new List<string>();
                    t_ProductStructList.Add(t_ProductStruct);
                }
                if(t_ProductStruct != null)
                {
                    t_ProductStruct.s_ProductListString.Add(t_MissionManagerContents[i]);
                }
            }
            m_MissionManagerStruct.SetProductStruct(t_ProductStructList);

            //Get product number
            for (int i = 0; i < t_MissionManagerContents.Count; i++)
            {
                //Check product section
                if (t_MissionManagerContents[i].Trim().CompareTo("[ProductNum]") == 0)
                {
                    t_MissionManagerContents.RemoveAt(i);
                    for (int j = 0; j < t_MissionManagerContents.Count; j++)
                    {
                        if (t_MissionManagerContents[j].Trim().StartsWith("Num=") == true)
                        {
                            m_MissionManagerStruct.s_ProductNum = int.Parse(t_MissionManagerContents[i].Trim().Split('=')[1].Trim());
                            t_MissionManagerContents.RemoveAt(i);
                            break;
                        }
                    }
                    break;
                }
            }
            //Get model and color
            List<ProductStruct> t_ProductList = m_MissionManagerStruct.GetProductStruct();
            for (int i = 0; i < t_ProductList.Count; i++)
            {
                while(t_ProductList[i].s_ProductListString.Count != 0)
                {
                    bool t_IndexJToZero = false;
                    for(int j = 0; j < t_ProductList[i].s_ProductListString.Count; j++)
                    {
                        t_Regex = new System.Text.RegularExpressions.Regex("^\\[Product(\\d*)\\]$");
                        t_Match = t_Regex.Match(t_ProductList[i].s_ProductListString[j]);
                        if(t_Match.Success == true)
                        {
                            t_ProductList[i].s_ProductID = int.Parse(t_Match.Groups[1].Value);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            t_IndexJToZero = true;
                        }
                        if(t_ProductList[i].s_ProductListString[j].IndexOf("ProductID=") == 0)
                        {
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            t_IndexJToZero = true;
                        }
                        t_Regex = new System.Text.RegularExpressions.Regex("^ProductName=(.*)$");
                        t_Match = t_Regex.Match(t_ProductList[i].s_ProductListString[j]);
                        if (t_Match.Success == true)
                        {
                            t_ProductList[i].s_ProductName = t_Match.Groups[1].Value;
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            t_IndexJToZero = true;
                        }
                        t_Regex = new System.Text.RegularExpressions.Regex("^TypeNum=(\\d*)$");
                        t_Match = t_Regex.Match(t_ProductList[i].s_ProductListString[j]);
                        if (t_Match.Success == true)
                        {
                            t_ProductList[i].s_TypeNum = int.Parse(t_Match.Groups[1].Value);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            t_IndexJToZero = true;
                        }

                        t_Regex = new System.Text.RegularExpressions.Regex("^Type_(\\d*)_ID=(\\d*)$");
                        t_Match = t_Regex.Match(t_ProductList[i].s_ProductListString[j]);
                        if(t_Match.Success == true)
                        {
                            int t_ModelID = int.Parse(t_Match.Groups[1].ToString());
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            string t_ModelName = t_ProductList[i].s_ProductListString[j].Split('=')[1];
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            int t_Width = int.Parse(t_ProductList[i].s_ProductListString[j].Split('=')[1]);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            int t_Height = int.Parse(t_ProductList[i].s_ProductListString[j].Split('=')[1]);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            int t_Thick = int.Parse(t_ProductList[i].s_ProductListString[j].Split('=')[1]);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            int t_ColorNum = int.Parse(t_ProductList[i].s_ProductListString[j].Split('=')[1]);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);

                            t_ProductList[i].AddModelStruct(new ModelStruct(t_ModelID, t_ModelName, t_Width, t_Height, t_Thick, t_ColorNum));
                            t_IndexJToZero = true;
                        }

                        t_Regex = new System.Text.RegularExpressions.Regex("^Type_(\\d*)_ColorNo_(\\d*)_ID=(\\d*)$");
                        t_Match = t_Regex.Match(t_ProductList[i].s_ProductListString[j]);
                        if(t_Match.Success == true)
                        {
                            int t_TypeID = int.Parse(t_Match.Groups[1].Value);
                            int t_ColorNo = int.Parse(t_Match.Groups[2].Value);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            string t_ColorName = t_ProductList[i].s_ProductListString[j].Split('=')[1];
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            bool t_BGTwice = bool.Parse(t_ProductList[i].s_ProductListString[j].Split('=')[1]);
                            t_ProductList[i].s_ProductListString.RemoveAt(j);
                            t_ProductList[i].GetModelStruct()[t_TypeID].AddColorStruct((new ColorStruct(t_ColorNo, t_ColorName, t_BGTwice)));
                            t_IndexJToZero = true;
                        }
                        if(t_IndexJToZero == true)
                        {
                            j = -1;
                        }
                        //m_MissionManagerStruct.GetProductStruct()[i].s_ProductListString[j]
                    }
                }
            }







            /*
                while (t_MissionManagerContents.Count != 0)
                {
                for(int i = 0; i < t_MissionManagerContents.Count; i++)
                {
                    //Check product section
                    if (t_MissionManagerContents[i].Trim().CompareTo("[ProductNum]") == 0)
                    {
                        t_MissionManagerContents.RemoveAt(i);
                        for (int j = 0; j < t_MissionManagerContents.Count; j++)
                        {
                            if (t_MissionManagerContents[j].Trim().StartsWith("Num=") == true)
                            {
                                m_MissionManagerStruct.s_ProductNum = int.Parse(t_MissionManagerContents[i].Trim().Split('=')[1].Trim());
                                t_MissionManagerContents.RemoveAt(i);
                                break;
                            }
                        }
                        break;
                    }
                    

                    //System.Text.RegularExpressions.Regex t_Regex = new System.Text.RegularExpressions.Regex("^\\[Product([0-9])\\]$");
                    //System.Text.RegularExpressions.Match t_Match = t_Regex.Match(t_MissionManagerContents[i].Trim());
                    if(t_Match.Success == true)
                    {
                        //ProductStruct t_ProductStruct = new ProductStruct();
                        t_MissionManagerContents.RemoveAt(i);
                        t_ProductStruct.s_ProductID = int.Parse(t_Match.Groups[1].Value);
                        t_MissionManagerContents.RemoveAt(i);

                        t_ProductStruct.s_ProductName = t_MissionManagerContents[i].Trim().Split('=')[1].Trim();
                        t_MissionManagerContents.RemoveAt(i);

                        t_ProductStruct.s_TypeNum = int.Parse(t_MissionManagerContents[i].Trim().Split('=')[1].Trim());
                        t_MissionManagerContents.RemoveAt(i);

                        m_MissionManagerStruct.AddProductStruct(t_ProductStruct);


                        for (int j = 0; j < t_MissionManagerContents.Count; j++)
                        {
                            ModelStruct t_ModelStruct = new ModelStruct();
                            t_Regex = new System.Text.RegularExpressions.Regex("^Type_(\\d+)_ID=(\\d+)$");
                            t_Match = t_Regex.Match(t_MissionManagerContents[j]);
                            if (t_Match.Success == true)
                            {
                                t_ModelStruct.s_ModelID = int.Parse(t_Match.Groups[1].Value);
                                t_MissionManagerContents.RemoveAt(j);
                                t_Regex = new System.Text.RegularExpressions.Regex($"^Type_{t_ModelStruct.s_ModelID}_Name=(.*)$");
                                t_Match = t_Regex.Match(t_MissionManagerContents[j]);
                                if (t_Match.Success == true)
                                {
                                    t_ModelStruct.s_TypeName = t_Match.Groups[1].ToString();
                                    t_MissionManagerContents.RemoveAt(j);
                                    t_Regex = new System.Text.RegularExpressions.Regex($"^Type_{t_ModelStruct.s_ModelID}_Width=(.*)$");
                                    t_Match = t_Regex.Match(t_MissionManagerContents[j]);
                                    if(t_Match.Success == true)
                                    {
                                        //t_ModelStruct.s_Width = 
                                    }
                                }

                            }
                            int t_TypeID = 0;
                            string t_TypeName = string.Empty;
                            int t_Width;
                            int t_Height;
                            int t_Thick;
                            int t_ColorNum;
                            int t_ColorNoID;
                            string ColorNoName;
                            bool ColorNoBGTwice;
                        }



                        
                        
                    }
                    
                }
             
            }*/
            return new MissionManagerStruct();
        }

       
    }
}
