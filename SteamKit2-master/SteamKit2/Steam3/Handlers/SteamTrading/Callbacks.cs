﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.ObjectModel;
using SteamKit2.Internal;

namespace SteamKit2
{
    public sealed partial class SteamTrading
    {
        /// <summary>
        /// This callback is fired when this client receives a trade proposal.
        /// </summary>
        public sealed class TradeProposedCallback : CallbackMsg
        {
            /// <summary>
            /// Gets the Trade ID of his proposal, used for replying.
            /// </summary>
            public uint TradeID { get; private set; }

            /// <summary>
            /// Gets the SteamID of the client that sent the proposal.
            /// </summary>
            public SteamID OtherClient { get; private set; }

            /// <summary>
            /// Gets the persona name of the client that sent the proposal.
            /// </summary>
            public string OtherName { get; private set; }


            internal TradeProposedCallback( CMsgTrading_InitiateTradeRequest msg )
            {
                this.TradeID = msg.trade_request_id;

                this.OtherClient = msg.other_steamid;

                this.OtherName = msg.other_name;
            }
        }


        /// <summary>
        /// This callback is fired when this client receives the response from a trade proposal.
        /// </summary>
        public sealed class TradeResultCallback : CallbackMsg
        {
            /// <summary>
            /// Gets the Trade ID that this result is for.
            /// </summary>
            public uint TradeID { get; private set; }

            /// <summary>
            /// Gets the response of the trade proposal.
            /// </summary>
            public EEconTradeResponse Response { get; private set; }

            /// <summary>
            /// Gets the SteamID of the client that responded to the proposal.
            /// </summary>
            public SteamID OtherClient { get; private set; }


            internal TradeResultCallback( CMsgTrading_InitiateTradeResponse msg )
            {
                this.TradeID = msg.trade_request_id;

                this.Response = ( EEconTradeResponse )msg.response;

                this.OtherClient = msg.other_steamid;
            }
        }


        /// <summary>
        /// This callback is fired when a trading session has started.
        /// </summary>
        public sealed class SessionStartCallback : CallbackMsg
        {
            /// <summary>
            /// Gets the SteamID of the client that this the trading session has started with.
            /// </summary>
            public SteamID OtherClient { get; private set; }


            internal SessionStartCallback( CMsgTrading_StartSession msg )
            {
                this.OtherClient = msg.other_steamid;
            }
        }
    }
}
