namespace UMS.Services
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.Home;

    public class HomeService : Service
    {
        public IEnumerable<AllRequestsForProfilingViewModel> GetAllReqForProfiling()
        {
            IEnumerable<SysAidRequest> result = Context.SysAidRequests.Where(r => r.RequestStatus != "Done");

            IEnumerable<AllRequestsForProfilingViewModel> requests = Mapper.Map<IEnumerable<SysAidRequest>, IEnumerable<AllRequestsForProfilingViewModel>>(result);

            return requests;
        }        
    }
}
