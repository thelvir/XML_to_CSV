using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmltocsv
{
    class ProcessResult
    {
        public String MachineID;
        public String MachineNumber;
        public String PackageNumber;
        public String StartedAt;
        public Boolean RejectionExists;
        public String EndedAt;
        public String SendedAt;
        public List<BundleLine> Lines;

        public string AsCsvRow()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}, {6}", this.MachineID, this.MachineNumber, this.PackageNumber, this.StartedAt, this.EndedAt, this.SendedAt, this.RejectionExists).ToString();
        }
    }
}
