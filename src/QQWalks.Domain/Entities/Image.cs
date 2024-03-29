﻿using Microsoft.AspNetCore.Http;
using QQWalks.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Domain.Entities;

public class Image:Auditable
{
    [NotMapped]
    public IFormFile File { get; set; }

    public string FileName { get; set; }
    public string? FileDescription { get; set; }
    public string FileExtension { get; set; }
    public long FileSizeInBytes { get; set; }

    public string FilePath { get; set; }
}
