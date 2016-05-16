using PageExample.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PageExample
{
    public class Windows
    {
        private static MainWindow main;
        private static OptionWindow option;
        public static MainWindow MainWindow
        {
            get
            {
                if (main == null)
                {
                    main = new MainWindow();
                }
                return main;
            }
        }

        public static OptionWindow OptionWindow
        {
            get
            {
                if(option == null)
                {
                    option = new OptionWindow();
                }

                return option;
            }
        }

        public static Page UsePage(Object obj)
        {
            if(obj is Student)
            {
                return new StudentPage((Student)obj);
            }
            if(obj is Cours)
            {
                return new CoursesPage((Cours)obj);
            }
            return null;
        }
    }
}
