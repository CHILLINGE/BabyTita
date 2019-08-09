using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public interface INavigable
    {
        /// <summary>
        /// 원하는 페이지로 이동하고 싶을 때 호출한다.
        /// </summary>
        event EventHandler<NavigateEventArgs> OnNavigate;


        /// <summary>
        /// 현재 페이지로 이동되었을 때 호출된다.
        /// </summary>
        /// <param name="fromEndpoint">이전 페이지의 endpoint</param>
        /// <param name="data">이전 페이지에서 전달된 데이터</param>
        void Navigated(string fromEndpoint, object data);
    }
}
