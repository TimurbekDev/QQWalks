using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Exceptions;

public class QQWalksException:Exception
{
    public int StatusCode { get; set; }
    public QQWalksException(int StatusCode, string message):base(message)
    {
        this.StatusCode = StatusCode;
    }
}
