using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		[STAThread]
		static void Main(string[] args)
		{
			Program.consoleRun();
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);

			//Form1 form = new Form1();
			//form.Visible = true;
			//form.TopMost = true;

			//Application.Run(form);
		}

		private void RunButton_Click(object sender, EventArgs e)
		{
			runTTMIK();
			if (MessageBox.Show("Your downloads are complete.", "Finished!", MessageBoxButtons.OK) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void runTTMIK()
		{
			StatusLabel.Text = "Started...";

			if (fileExtTextBox.Text.CompareTo("") == 0)
			{
				fileExtTextBox.Text = "(mp3|pdf)";
			}
			string fileExt = fileExtTextBox.Text;

			string regex = @"http[s]?://www\.talktomeinkorean\.com/lessons/[^""]*";//@"http[s]?://www\.talktomeinkorean\.com/lessons/[^-\d]*\-(\d+)\-[^-\d]*\-(\d+)";
			string ext = @"http[s]?://[^/]*(/[^/\.]*)*\." + fileExt;

			string[] curriculumHtml = GetWebsiteSource(websiteTextBox.Text).Split('\n');

			StatusLabel.Text = "-Downloaded HTML\n-Searching for *." + fileExt + "...";

			string filepath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\TTMIK\";

			CreateFolders(filepath);

			foreach (string s in curriculumHtml) //look for links to lessons
			{
				string dl = Regex.Replace(Regex.Match(s, regex).ToString(), "\"", "");

				if (dl.CompareTo("") != 0)
				{
					string[] lessonHtml = GetWebsiteSource(dl).Split('\n');

					foreach (string t in lessonHtml) //look for .fileExt in lessons
					{
						string dlLocation = Regex.Match(t, ext).ToString();
						string filename = Regex.Match(dlLocation, @"([^/])*\." + fileExt).ToString();
						string location = filepath;

						if (Regex.Match(filename, @"pdf").ToString().CompareTo("pdf") == 0)
						{
							location += @"PDF\" + filename;
						}
						else
						{
							location += @"MP3\" + filename;
						}

						if (dlLocation.CompareTo("") != 0 && !(File.Exists(location)))
						{
							DownloadPdfMp3(dlLocation, location);
						}
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fileExtTextBox.Text = "(mp3|pdf)";
		}

		public void CreateFolders(string baseFilepath)
		{
			string mp3Filepath = baseFilepath + @"\MP3\";
			string pdfFilepath = baseFilepath + @"\PDF\";

			System.IO.Directory.CreateDirectory(baseFilepath);
			System.IO.Directory.CreateDirectory(mp3Filepath);
			System.IO.Directory.CreateDirectory(pdfFilepath);
		}

		public void DownloadPdfMp3(string urlAddress, string filename)
		{
			try
			{
				StatusLabel.Text = "Downloading " + filename + "..."; 
				WebClient wClient = new WebClient();
				wClient.DownloadFileAsync(new Uri(urlAddress), filename);
				StatusLabel.Text = "Downloaded to " + filename;
				StatusLabel.Text = "Downloaded"; 

			}
			catch (WebException e)
			{
				if (MessageBox.Show(("ERROR: could not download file.\n" + e.Response + "\n" + e.Message), ":(", MessageBoxButtons.OK) == DialogResult.OK)
				{
					Application.Exit();
				}
				
			}
		}

		public string GetWebsiteSource(string url)
		{
			try
			{
				//Create request for given url
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

				//Create response-object
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				//Take response stream
				StreamReader sr = new StreamReader(response.GetResponseStream());

				//Read response stream (html code)
				string html = sr.ReadToEnd();
				//while (!sr.EndOfStream)
				//{

				//}
				//Close streamreader and response
				sr.Close();
				response.Close();

				//return source
				return html;
			}
			catch (WebException e)
			{
				MessageBox.Show("ERROR: Connection timed out.\n" + e.StackTrace, ":(", MessageBoxButtons.OK);
				return "Empty";
			}
		}

	}
}
