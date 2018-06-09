using System;

namespace Aerodrom.Helper
{
    interface INavigationService
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);

    }
}