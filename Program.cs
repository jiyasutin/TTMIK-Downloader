using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace ConsoleApplication3
{
	class Program
	{

		public static void consoleRun()
		{
			//Console.Write("Pick a file extension: ");
			string fileExt = "(pdf|mp3)";//Console.ReadLine();//

			string regex = @"http[s]?://www\.talktomeinkorean\.com/lessons/[^""]*";//@"http[s]?://www\.talktomeinkorean\.com/lessons/[^-\d]*\-(\d+)\-[^-\d]*\-(\d+)";
			string ext = @"http[s]?://[^/]*(/[^/\.]*)*\." + fileExt;

			string[] curriculumHtml = GetWebsiteSource(@"http://www.talktomeinkorean.com/curriculum/").Split('\n');

			Console.WriteLine("-Downloaded HTML\n-Searching for *." + fileExt + "...");

			string filepath = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\TTMIK\";

			CreateFolders(filepath);

			int i = 0; //testing
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
						else if(Regex.Match(filename, @"mp3").ToString().CompareTo("mp3") == 0)
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
			Console.WriteLine("\n-Downloads complete.\n-Files are stored at {0}\n-Press any key to finish.", filepath);
			Console.ReadKey();
		}

		public static void CreateFolders(string baseFilepath)
		{
			string mp3Filepath = baseFilepath + @"\MP3\";
			string pdfFilepath = baseFilepath + @"\PDF\";

			System.IO.Directory.CreateDirectory(baseFilepath);
			System.IO.Directory.CreateDirectory(mp3Filepath);
			System.IO.Directory.CreateDirectory(pdfFilepath);
		}

		public static void DownloadPdfMp3(string urlAddress, string filename)
		{
			try
			{
				Console.WriteLine("-Downloading \t{0}...", urlAddress);
				WebClient wClient = new WebClient();
				wClient.DownloadFile(urlAddress, filename);
				Console.WriteLine("-Downloaded to \t{0}", filename);
			}
			catch (WebException e)
			{
				Console.WriteLine("ERROR: could not download file.\n{0}\n{1}",e.Response,e.Message);
			}
		}

		public static string GetWebsiteSource(string url)
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
				Console.WriteLine("-ERROR: Connection timed out.\n" + e.StackTrace);
				return "";
			}
		}
	}
}
