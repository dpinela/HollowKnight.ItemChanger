﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ItemChanger.UIDefs
{
    public class MsgUIDef : UIDef
    {
        public IString name;
        public IString shopDesc;
        public ISprite sprite;

        public override string GetPostviewName()
        {
            return name.GetValue();
        }

        public override string GetPreviewName()
        {
            return name.GetValue();
        }

        public override string GetShopDesc()
        {
            return shopDesc.GetValue();
        }

        public override Sprite GetSprite()
        {
            return sprite.GetValue();
        }

        public override void SendMessage(MessageType type, Action callback)
        {
            if ((type & MessageType.Corner) == MessageType.Corner)
            {
                Internal.MessageController.Enqueue(GetSprite(), GetPostviewName());
            }

            callback?.Invoke();
        }

        // Remember that Clone is not memberwise, so it must be overridden in any descendent.
        public override UIDef Clone()
        {
            return new MsgUIDef
            {
                name = name.Clone(),
                shopDesc = shopDesc.Clone(),
                sprite = sprite.Clone()
            };
        }
    }
}