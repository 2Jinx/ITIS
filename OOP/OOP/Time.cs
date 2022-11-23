using System;
namespace OOP
{
	internal class Time
	{
		private int hours;
		private int minutes;
		private int seconds;

        public void SetHours(int h)
        {
            hours = h;
        }

        public int GetHours()
        {
            return hours;
        }

        public void SetMinutes(int m)
        {
            minutes = m;
        }

        public int GetMinutes()
        {
            return minutes;
        }

        public void SetSeconds(int s)
        {
            seconds = s;
        }

        public int GetSeconds()
        {
            return seconds;
        }

        public Time(int h, int m, int s)
        {
            if (h < 0 || m < 0 || s < 0)
                throw new ArgumentException("время не может быть отрицательным!");

            Hours = h;
            Minutes = m;
            Seconds = s;
        }

        public Time(int h, int m) : this(h, m, 0)
        {
            ///
        }
        public Time(int s) : this(0, 0, s)
        {
            ///
        }
        public Time() : this(0, 0, 0)
        {
            ///
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value < 0)
                {
                    if (hours + value < 0)
                    {
                        Hours = 24 + hours + value;
                    }
                    else
                    {
                        hours -= value % 24;
                    }
                }
                else
                {
                    hours = value % 24;
                }
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value < 0)
                {
                    if (minutes + value < 0)
                    {
                        Hours += (minutes + value) / 60;
                        if (-((minutes + value) / 60) * 60 + value < 0)
                        {
                            Hours -= 1;
                            Minutes = -((minutes + value) / 60) * 60 + value + 60;
                        }
                        else
                            Minutes = -((minutes + value) / 60) * 60 + value;
                    }
                    else
                    {
                        Minutes += value % 60;
                        Hours += value / 60;
                    }
                }
                else
                {
                    minutes = value % 60;
                    Hours += value / 60;
                }
            }
        }
     
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (value < 0)
                {
                    if (seconds + value < 0)
                    {
                        Minutes += (seconds + value) / 60;
                        if (-((seconds + value) / 60) * 60 + value < 0)
                        {
                            Minutes -= 1;
                            Seconds = -((seconds + value) / 60) * 60 + value + 60;
                        }
                        else
                            Seconds = -((seconds + value) / 60) * 60 + value;
                    }
                    else
                    {
                        Seconds += value % 60;
                        Minutes += value / 60;
                    }
                }
                else
                {
                    seconds = value % 60;
                    Minutes += value / 60;
                }
            }
        }

        public override string ToString()
        {
            if (Hours > 10)
            {
                if(Minutes > 10)
                {
                    if(Seconds > 10)
                    {
                        return $"{Hours}:{Minutes}:{Seconds}";
                    }
                    else
                    {
                        return $"{Hours}:{Minutes}:0{Seconds}";
                    }
                }
                else
                {
                    if (Seconds > 10)
                    {
                        return $"{Hours}:0{Minutes}:{Seconds}";
                    }
                    else
                    {
                        return $"{Hours}:0{Minutes}:0{Seconds}";
                    }
                }
            }
            else
            {
                if (Minutes > 10)
                {
                    if (Seconds > 10)
                    {
                        return $"0{Hours}:{Minutes}:{Seconds}";
                    }
                    else
                    {
                        return $"0{Hours}:{Minutes}:0{Seconds}";
                    }
                }
                else
                {
                    if (Seconds > 10)
                    {
                        return $"0{Hours}:0{Minutes}:{Seconds}";
                    }
                    else
                    {
                        return $"0{Hours}:0{Minutes}:0{Seconds}";
                    }
                }
            }
        }

        public int InSeconds()
        {
            return Seconds + (Minutes * 60) + (Hours * 60 * 60);
        }

        public static Time operator +(Time t1, Time t2)
        {
            return new Time(t1.Hours + t2.Hours, t1.Minutes + t2.Minutes, t1.Seconds + t2.Seconds);
        }

        public static Time operator -(Time t1, Time t2)
        {
            return new Time(t1.Hours - t2.Hours, t1.Minutes - t2.Minutes, t1.Seconds - t2.Seconds);
        }

        public static Time operator *(Time t, int a)
        {
            return new Time(0,0,t.InSeconds() * a);
        }

        public static Time operator /(Time t, int a)
        {
            return new Time(0,0,t.InSeconds() / a);
        }

    }
}

