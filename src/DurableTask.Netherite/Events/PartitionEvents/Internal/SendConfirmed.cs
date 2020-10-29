﻿//  ----------------------------------------------------------------------------------
//  Copyright Microsoft Corporation. All rights reserved.
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  ----------------------------------------------------------------------------------

namespace DurableTask.Netherite
{
    using System.Runtime.Serialization;

    [DataContract]
class SendConfirmed : PartitionUpdateEvent
    {
        [DataMember]
        public long Position { get; set; }

        [IgnoreDataMember]
        public string WorkItemId => $"{this.PartitionId:D2}-C{this.Position:D10}";

        [IgnoreDataMember]
        public override EventId EventId => EventId.MakePartitionInternalEventId(this.WorkItemId);

        public override void DetermineEffects(EffectTracker effects)
        {
            effects.Add(TrackedObjectKey.Outbox);
        }
    }
}
