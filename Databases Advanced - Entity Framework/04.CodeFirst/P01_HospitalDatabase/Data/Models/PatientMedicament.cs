﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {

        public PatientMedicament()
        {

        }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }


        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}
