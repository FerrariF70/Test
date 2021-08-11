using System.Threading.Tasks;
using System.Collections;

namespace Test.ExportFile
{
    public interface IExport
    {
        Task CSV(IList listOfCar);
        Task Txt(IList listOfCar);
    }
}
