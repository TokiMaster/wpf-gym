using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Entities
{
    public class Training
    {
        private int _id;
        private DateTime _startDate;
        private TimeSpan _duration;
        private Status _status;
        private User _instructor;
        private User _beginner;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime date
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public TimeSpan duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public Status status
        {
            get { return _status; }
            set { _status = value; }
        }
        public User instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }
        public User beginner
        {
            get { return _beginner; }
            set { _beginner = value; }
        }

        public Training()
        {

        }
        public Training(int id, DateTime startTime,TimeSpan duration, Status status, User instructor, User beginner)
        {
            this._id = id;
            this._startDate = startTime;
            this._duration = duration;
            this._status = status;
            this._instructor = instructor;
            this._beginner = beginner;
        }
    }
}
