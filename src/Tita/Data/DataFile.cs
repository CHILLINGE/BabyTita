using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tita
{
    /// <summary>
    /// 파일에 ClassInfo 정보들을 읽고 쓰는 객체
    /// </summary>
    public class DataFile
    {
        /// <summary>
        /// 연결된 파일의 정보
        /// </summary>
        public FileInfo Info { get; private set; }

        /// <summary>
        /// 어느 학교의 db인지
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// 언제 기준의 db인지
        /// </summary>
        public string When { get; set; }

        /// <summary>
        /// 기타 사항
        /// </summary>
        public string Etc { get; set; }


        public DataFile(FileInfo targetFile)
        {
            Info = targetFile;
        }

        public DataFile(string targetPath) : this(new FileInfo(targetPath))
        {

        }


        /// <summary>
        /// 유효한 db파일인지 체크
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (!Info.Exists)
                {
                    return false;
                }

                // Need more

                return true;
            }
        }


        /// <summary>
        /// 파일에서 ClassInfo 들을 파싱해서 읽어온다.
        /// </summary>
        /// <returns>ClassInfo의 리스트</returns>
        public ClassInfoList LoadClassInfo()
        {
            

            string xmldata = "";
            using (var stream = new StreamReader(Info.OpenRead()))
            {
                xmldata = stream.ReadToEnd();
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmldata);

            var root = xdoc.SelectSingleNode("subjectdb");

            School = root["school"]?.InnerText;
            When = root["when"]?.InnerText;
            
            

            ClassInfoList result = ParseData(root);
            

            return result;
        }

        /// <summary>
        /// ClassInfo의 리스트를 해당 db에 저장한다.
        /// </summary>
        /// <param name="classes">ClassInfo의 리스트</param>
        public void SaveClassInfo(List<ClassInfo> classes)
        {
            // Need more
        }


        private ClassInfoList ParseData(XmlNode xdoc)
        {
            ClassInfoList result = new ClassInfoList();

            

            
            var data = xdoc.SelectSingleNode("data");

            foreach (XmlNode groupnode in data.ChildNodes)
            {
                if (groupnode.Name == "group")
                {
                    string groupname = groupnode.Attributes.GetNamedItem("name").Value;
                    if (!result.Groups.ContainsKey(groupname))
                    {
                        result.Groups[groupname] = new List<ClassInfo>();
                    }
                    

                    foreach (XmlNode subjectnode in groupnode.ChildNodes)
                    {


                        ClassInfo subject = new ClassInfo();

                        if (subjectnode["name"] == null)
                        {
                            throw new XmlException(string.Format("Subject doesn't have name in group '{0}'", groupname));
                            
                        }

                        subject.Name = subjectnode["name"].InnerText;

                        subject.Professor = subjectnode["prof"]?.InnerText;

                        

                        if (int.TryParse(subjectnode["grade"]?.InnerText, out int gradeval))
                        {
                            subject.Grade = gradeval;
                        }
                        else
                        {
                            subject.Grade = 0;
                        }

                        
                        subject.Major = subjectnode["major"]?.InnerText;


                        

                        if (int.TryParse(subjectnode["division"]?.InnerText, out int divval))
                        {
                            subject.Division = divval;
                        }
                        else
                        {
                            subject.Division = 0;
                        }

                        try
                        {
                            subject.Time = ParseTime(subjectnode["time"]);
                        }
                        catch (Exception)
                        {
                            throw new XmlException(string.Format("Invalid time format in subject {0}", subject.Name));
                        }
                        



                        result.Groups[groupname].Add(subject);
                    }


                }

            }

            return result;

        }

        private ClassTime ParseTime(XmlNode node)
        {
            ClassTime result = new ClassTime();

            foreach (XmlNode timepart in node.ChildNodes)
            {
                var attr = timepart.Attributes;

                ClassTimeItem timeitem = new ClassTimeItem(
                        ClassTimeItem.ConvertDayBack(attr.GetNamedItem("day").Value),
                        ConvertTime(attr.GetNamedItem("fr").Value),
                        ConvertTime(attr.GetNamedItem("to").Value)
                    );

                result.Items.Add(timeitem);
            }


            return result;
        }

        private TimeSpan ConvertTime(int timeval)
        {
            return new TimeSpan(timeval / 100, timeval % 100, 0);
        }

        private TimeSpan ConvertTime(string timestr)
        {
            return ConvertTime(int.Parse(timestr));
        }
    }
}
