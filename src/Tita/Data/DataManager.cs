using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tita
{
    /// <summary>
    /// 지정된 db폴더의 db들을 관리한다.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// db폴더 경로
        /// </summary>
        public string FolderPath { get; set; }

        public DataManager(string folderpath = ".")
        {
            FolderPath = folderpath;
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }

        /// <summary>
        /// 폴더를 읽어서 db들의 목록을 가져온다.
        /// </summary>
        /// <returns>ClassInfo 를 얻어올 수 있는 DataFile 객체의 리스트</returns>
        public List<DataFile> GetFiles()
        {
            List<DataFile> result = new List<DataFile>();

            

            DirectoryInfo di = new DirectoryInfo(FolderPath);

            FileInfo[] files = di.GetFiles("*.classdb");

            foreach (var file in files)
            {
                result.Add(new DataFile(file));
            }

            return result;
        }


        /// <summary>
        /// 새로운 db파일을 만든다.
        /// </summary>
        /// <param name="dbname">db파일의 이름</param>
        /// <param name="school">대상 학교</param>
        /// <param name="when">대상 시기</param>
        /// <param name="etc">기타 사항</param>
        /// <returns></returns>
        public DataFile CreateDataFile(string dbname, string school, string when, string etc="")
        {
            string rpath = Path.Combine(FolderPath, dbname + ".classdb");

            if (File.Exists(rpath))
            {
                throw new IOException("File \"" + rpath + "\" already exists.");
            }

            DataFile cur = new DataFile(rpath);
            cur.School = school;
            cur.When = when;
            cur.Etc = etc;

            cur.SaveClassInfo(new List<ClassInfo>());

            return cur;
        }
        
    }
}
