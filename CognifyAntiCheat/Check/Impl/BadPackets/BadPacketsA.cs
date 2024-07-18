﻿using CognifyAntiCheat.Constant;
using CognifyAntiCheat.Listener;
using CognifyAntiCheat.Listener.Event.Impl.Player;
using CognifyAntiCheat.Utils;

namespace CognifyAntiCheat.Check.Impl.BadPackets;

/// <summary>
/// This check will kick those players who use AUM
/// </summary>
public class BadPacketsA : Check
{
    public BadPacketsA(PlayerControl target) : base("BadPacketsA", target)
    {
        Description = "This check will kick those players who use AUM";
    }

    [EventHandler(EventHandlerType.Postfix)]
    public void OnRPCReceived(PlayerHandleRpcEvent @event)
    {
        if (!AmongUsClient.Instance.AmHost) return;
        var player = @event.Player;
        if (player.IsSamePlayer(PlayerControl.LocalPlayer)) return;
        if (player.IsSamePlayer(Target) && @event.CallId == CheckConstant.AmongUsMenuRpc) Fail();
    }

    public override IListener GetListener() => this;
}