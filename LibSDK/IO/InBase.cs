using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.IO
{
    public abstract class  InBase
    {
        private KTimer CheckTM;

        private bool _Status;

        public bool ReverseStatus {  get; set; }
           
        protected bool Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                bool flag = this._Status != value;
                if (flag)
                {
                    this._Status = value;
                    this.CheckTM.Restart();
                }
            }
        }

        protected bool ReadOn()
        {
          return (this.ReverseStatus ? (!this.Status) : this.Status);
        }
        protected bool ReadOff()
        {
            return (this.ReverseStatus ? this.Status : (!this.Status));
        }
        protected bool ReadOn(long millisecond)
        {
            return this.ReadOn() & this.CheckTM.IsOn(millisecond);
        }

        protected bool ReadOff(long millisecond)
        {
          return this.ReadOff() & this.CheckTM.IsOn(millisecond);
        }
        protected InBase()
        {
          this.ReverseStatus = false;
          this.CheckTM = new KTimer();
        }
    }
}
