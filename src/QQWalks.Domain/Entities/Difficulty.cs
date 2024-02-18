using QQWalks.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Domain.Entities;

public class Difficulty:Auditable
{
    public string Name { get; set; }
}
