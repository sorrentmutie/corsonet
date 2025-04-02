using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary.Core.Mappe;

public class ParametriMappa
{
    public string Id { get; set; }
    public float Latitudine { get; set; }
    public float Longitudine { get; set; }
    public int Zoom { get; set; }
}
