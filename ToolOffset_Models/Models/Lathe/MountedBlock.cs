﻿using System;
using System.Collections.Generic;

namespace ToolOffset_Models.Models.Lathe
{
    public class MountedBlock
    {
        public int Id { get; set; }
        public List<MountedPosition> Positions { get; set; }

    }
}
