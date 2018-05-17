﻿using Logs.Controller;
using Logs.ImageService.Logging.Modal;
using Logs.Modal.Event;
using System;
using System.Net.Sockets;

namespace Logs.Server
{ 
    public interface IClientHandler
    {
        void HandleClient(TcpClient c);
        void SetController(IImageController c);
        void OnCommandRecieved(object sender, CommandRecievedEventArgs e);
        void OnCloseDirectory(object sender, DirectoryCloseEventArgs e);
        void OnLogMessageRecieved(object sender, MessageRecievedEventArgs e);
        event EventHandler<CommandRecievedEventArgs> CommandRecieved;
        event EventHandler<DirectoryCloseEventArgs> CloseCommand;
    }
}
