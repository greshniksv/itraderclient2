using System;

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace itcClassess
{
    public static class Status
    {
        public static List<Label> Labels = new List<Label>();
        public delegate void NotifyHandler();
        private static string currentStatus = null;
        public static void AddLabel(Label lbl)
        {
            if (!Labels.Contains(lbl))
                Labels.Add(lbl);
        }

        public static void UpdateStatus(string status)
        {
            UpdateStatus(status, -1);
        }

        public static void UpdateStatus(string status, int percent)
        {
            Status.currentStatus = status;
            string strPercent = "";
            if (percent != -1)
            {
                strPercent = string.Format(" [{0}%]", percent);
            }
            foreach (Label lbl in Labels)
            {
                Form parent = null;
                lbl.Invoke
                    (
                        new NotifyHandler(
                            delegate()
                            {
                                parent = (Form)lbl.Parent;
                            }
                        )
                    );

                if (parent.InvokeRequired)
                {
                    parent.Invoke
                    (
                        new NotifyHandler(
                            delegate()
                            {
                                lbl.Text = string.Format("{0}{1}", status, strPercent);
                            }
                        )
                    );
                }
                else
                    lbl.Text = string.Format("{0}{1}", status, strPercent);
            }
        }

        public static void UpdateStatus(string status, Label lbl)
        {
            UpdateStatus(status, -1, lbl);
        }

        public static void UpdateStatus(string status, int percent, Label lbl)
        {
            Status.currentStatus = status;
            string strPercent = "";
            if (percent != -1)
            {
                strPercent = string.Format(" [{0}]", percent);
            }
            Form parent = (Form)lbl.Parent;
            if (parent.InvokeRequired)
            {
                parent.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            lbl.Text = string.Format("{0}{1}", status, strPercent);
                        }
                    )
                );
            }
            else
                lbl.Text = string.Format("{0}{1}", status, strPercent);
            
        }

        public static string CurrentStatus
        {
            get { return Status.currentStatus; }
        }
    }
}
