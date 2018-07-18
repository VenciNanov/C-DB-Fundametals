using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data

{
   public static class Configuration
    {
        public static string ConnectionString { get; set; } = @"Server=DESKTOP-LFC551Q\SQLEXPRESS;Database=Student System;Integrated Security=true";
    }
}
