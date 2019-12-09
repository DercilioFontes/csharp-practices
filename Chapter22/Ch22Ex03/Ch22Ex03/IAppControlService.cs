using System.ServiceModel;

namespace Ch22Ex03
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAppControlService" in both code and config file together.
    [ServiceContract]
    public interface IAppControlService
    {
        [OperationContract]
        void SetRadius(int radius, string foreTo, int seconds);
    }
}
