using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Upload6.Models;

public class students
{
    [Key]
    public int studentID { get; set; }
    public string? name { get; set; }
    public string? img { get; set; }
}