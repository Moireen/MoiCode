namespace SenseTimeCodingInterview
{

    public class MyDate
    {

        static int[] iMonthDays = new int[12] {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        static int[] iMonthDaysAdd = new int[13] {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};
        
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        bool LeapYear(int year); //闰年判断
        
        static bool LeapYear(int year){
            return (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0);
        }
        
        int GetMonthDays(int year, int month){
            if(month < 1 || year < 1
              || month > 12 || year > 9999){
                //抛出异常
            } 
            int iDays = iMonthDays[month - 1];
            if(month == 2 && !LeapYear(year)){
                iDays = 28;
            }
        }

        static int GetMyDateDays(MyDate myD){
            int iDays = (myD.Year - 1) * 365;    // + (myD.Month - 1) * 30 + (myD.Day - 1)
            iDays += (myD.Year / 4);
            iDays -= (myD.Year / 100);
            iDays += (myD.Year / 400);
            
            //for(int i = myD.Month - 1; i > 0; i--){
            //    iDays += GetMonthDays(myD.Year, i);
            //}
            iDays += iMonthDaysAdd(myD.Month - 1);
            if(myD.Month > 2 && !LeapYear(year)){
                iDays--;
            }
            
            iDays += (myD.Day - 1);
        }
        
        public MyDate(int year, int month, int day)
        {
            if(day < 1 || month < 1 || year < 1
              || day > 31 || month > 12 || year > 9999){
                //抛出异常
            } else if(day > iMonthDays[month]){
                //抛出异常
            } else if(month == 2 && day == 29 && !LeapYear(year)){    //2月
                //抛出异常
            } 
            
            this.Year = year;
            this.Month = month;
            this.Day = day;


        }


        public static int operator -(MyDate d1, MyDate d2)
        {

            //int iDays = 

            return GetMyDateDays(d1) - GetMyDateDays(d2);

        }


        public override string ToString()
        {

            return $"{this.Year:D04}-{this.Month:D02}-{this.Day:D02}";
        }

    }

}

