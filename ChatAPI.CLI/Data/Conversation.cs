using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ChatAPI.CLI.Data
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class Conversation
	{
		[JsonProperty(nameof(UserId))]
		public Guid UserId { get; set; }
		[JsonProperty(nameof(UserSaid))]
		public List<string> UserSaid { get; private set; }
		[JsonProperty(nameof(RobotSaid))]
		public List<string> RobotSaid { get; private set; }

		public Conversation(Guid userId)
		{
			this.UserId = userId;
			this.UserSaid = new List<string>();
			this.RobotSaid = new List<string>();
		}
		public Conversation(Guid userId, IEnumerable<string> userSaid, IEnumerable<string> robotSaid)
		{
			UserId = userId;
			UserSaid = new List<string>(userSaid ?? new string[0]);
			RobotSaid = new List<string>(robotSaid ?? new string[0]);
		}
	}
}
