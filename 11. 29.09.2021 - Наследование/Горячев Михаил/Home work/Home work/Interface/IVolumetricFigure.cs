using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work.Interface
{
    // Интерсфейс Объемная фигура
    public interface IVolumetricFigure
    {
        // площадь
        double Area();

        // объём
        double Volume();
    }
}