using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class ActivateMemberTempInfoResult : ApiResult
    {
        [JsonProperty("common_field_list")]
        public CommonField[] CommonFieldList { get; set; }

        [JsonProperty("custom_field_list")]
        public CustomField[] CustomFieldList { get; set; }

    }
}
