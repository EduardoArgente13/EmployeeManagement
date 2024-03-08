using Microsoft.EntityFrameworkCore;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement
{
    [Index(nameof(Employee.RFC), IsUnique = true)]

    public class Employee
    {
        public int ID { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        [RegularExpression("^[A-Z]{4}\\d{6}[A-Z0-9]{3}$")]
        [Alternatekey]
        public required string RFC { get; set; }

        public DateTime BornDate { get; set; }

        public EmployeeStatus Status { get; set; }
    }

    public enum EmployeeStatus
    {
        NotSet,
        Active,
        Inactive,
    }
}

