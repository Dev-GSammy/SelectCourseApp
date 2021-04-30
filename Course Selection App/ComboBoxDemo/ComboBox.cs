using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxDemo
{
    public partial class ComboBox : Form
    {
        DataTable dtClinic = new DataTable(); //to store the data for the first combobox
        DataTable dtDoctor = new DataTable(); //for the second combobox
        DataTable dtDSpecialClinicDoctor = new DataTable(); //to store data links first and second comboboxes
        public ComboBox()
        {
            InitializeComponent();
        }

        private void ComboBox_Load(object sender, EventArgs e)
        {
            FillDataTable1(); //implementation of the new created methods to populate the tables
            FillDataTable2();

            comboBox1.DataSource = dtClinic;  //combobox 1 gets data from table dtClinic
            comboBox1.DisplayMember = "ClinicName"; //The visible member from the combobox
        }

        //assigning columns  to each combobox label as their values
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblClinicName.Text = dtClinic.Rows[comboBox1.SelectedIndex]["ClinicName"].ToString();
            lblClinicAddress.Text = dtClinic.Rows[comboBox1.SelectedIndex]["ClinicAddress"].ToString();
            lblClinicContact.Text = dtClinic.Rows[comboBox1.SelectedIndex]["ClinicContact"].ToString();
            lblClinicRating.Text = dtClinic.Rows[comboBox1.SelectedIndex]["ClinicRating"].ToString();
            //populating the dtDSpecialClinicDoctor table with the rows like clinicID = 1, and referring to each row of the clinicID column in the dtdoctor table, then copying this value as a table.
            dtDSpecialClinicDoctor = dtDoctor.Select("ClinicID = " + dtClinic.Rows[comboBox1.SelectedIndex]["ClinicID"]).CopyToDataTable();
            comboBox2.DataSource = dtDSpecialClinicDoctor; //combobox2 gets data from dtdspecialdoctor table
            comboBox2.DisplayMember = "DoctorName";
        }
        //populating the table for first combobox
        private void FillDataTable1()
        {
            dtClinic.Columns.Add("ClinicID", typeof(int));
            dtClinic.Columns.Add("ClinicName");
            dtClinic.Columns.Add("ClinicAddress");
            dtClinic.Columns.Add("ClinicContact");
            dtClinic.Columns.Add("ClinicRating");

            dtClinic.Rows.Add(1, "UCH Ibadan", "Off Mokola road, Ibadan", "08100209234", "7/10");
            dtClinic.Rows.Add(2, "OAUTHC ife", "Opp Face 2 Oda road", "08102938322", "5/10");
            dtClinic.Rows.Add(3, "Health Centre, Akure", "Inside FUTA", "09077362837", "1/10");
            dtClinic.Rows.Add(4, "State Hospital, Ondo", "Mile 12, Ondo State", "09136772637", "8/10");
            dtClinic.Rows.Add(5, "LASU Hospital", "Inside LASU Lagos", "07036324555", "6/10");
        }
        //populating the table for second combobox
        private void FillDataTable2()
        {
            dtDoctor.Columns.Add("ClinicID", typeof(int));
            dtDoctor.Columns.Add("DoctorName");
            dtDoctor.Columns.Add("DoctorSpecialty");
            dtDoctor.Columns.Add("DoctorContact");

            dtDoctor.Rows.Add(1, "Dr. Peter Parker", "Neurologist", "09772882771");
            dtDoctor.Rows.Add(1, "Dr. Ivan Adeyi", "Heart Surgeon", "081993377483");
            dtDoctor.Rows.Add(1, "Dr. Fatunmbi Samuel", "Nose, Ear & Mouth Specialist", "09772882771");
            dtDoctor.Rows.Add(1, "Dr. Rida PeterFord", "Baby Diseases Specialist", "09772882771");
            dtDoctor.Rows.Add(2, "Dr. Andela", "Dentist", "9927388222");
            dtDoctor.Rows.Add(2, "Dr. Rita Orji", "Optician", "07022883737");
            dtDoctor.Rows.Add(2, "Dr. Ben Carson", "Heart Surgeon", "09127663773");
            dtDoctor.Rows.Add(2, "Dr. Femi Adebayo", "Cardiologist", "080736545622");
            dtDoctor.Rows.Add(3, "Dr. Boyinbode", "Neurologist", "0817264782");
            dtDoctor.Rows.Add(3, "Dr. Daramola", "Dentist", "070874466228");
            dtDoctor.Rows.Add(3, "Dr. Sarumi", "Cardiologist", "08123112345");
            dtDoctor.Rows.Add(3, "Dr. IgboranSoluwa", "Optician", "080999226671");
            dtDoctor.Rows.Add(4, "Dr. Meterson", "Nose Ear & Mouth Specialist", "08100012310");
            dtDoctor.Rows.Add(4, "Dr. IceSkate", "Neurologist", "080198662882");
            dtDoctor.Rows.Add(4, "Dr. Ford Henry", "Baby Diseases", "0128938832");
            dtDoctor.Rows.Add(4, "Dr. Tesla Allison", "Neurosurgeon", "08123428859");
        }
        //assigning columns  to each combobox label as their values
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDoctorName.Text = dtDSpecialClinicDoctor.Rows[comboBox2.SelectedIndex]["DoctorName"].ToString();
            lblDoctorSpecialty.Text = dtDSpecialClinicDoctor.Rows[comboBox2.SelectedIndex]["DoctorSpecialty"].ToString();
            lblDoctorContact.Text = dtDSpecialClinicDoctor.Rows[comboBox2.SelectedIndex]["DoctorContact"].ToString();
        }
    }
}