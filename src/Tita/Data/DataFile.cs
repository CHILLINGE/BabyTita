using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<ClassInfo> LoadClassInfo()
        {
            List<ClassInfo> result = new List<ClassInfo>();

            // Need more

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

    }
}
