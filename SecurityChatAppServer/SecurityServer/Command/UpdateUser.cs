﻿using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Command
{
    public class UpdateUser : CommandBase<ChatSession, ChatRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, ChatRequestInfo requestInfo)
        {
            string source = requestInfo.Body;
            int pos_1 = source.IndexOf(session.SPLITER);
            int pos_2 = source.IndexOf(session.SPLITER, pos_1 + 1);

            // 顺序：用户名、昵称、签名
            string username = source.Substring(0, pos_1);
            string nickname = source.Substring(pos_1 + 1, pos_2 - pos_1 - session.SPLITER.Length);
            string signature = source.Substring(pos_2 + session.SPLITER.Length);

            ChatServer.Data_Operate.UpdateUser(username, nickname, signature);
        }
    }
}
