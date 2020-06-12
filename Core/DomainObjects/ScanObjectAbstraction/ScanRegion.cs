﻿using System.IO;

namespace Core.DomainObjects.ScanObjectAbstraction
{
    public class ScanRegion
    {

        public ulong Offset { get; }  //Смещение относительно начала контента
        public ulong Size { get; } //Размер сегмента

        public IObjectContent Content { get; }

        public ScanRegion(ulong Offset, ulong Size, IObjectContent Content)
        {
            this.Offset = Offset;
            this.Size = Size;
            this.Content = Content;
        }

        public byte[] Read(ulong Position)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Content.Path, FileMode.Open)))
            {
                byte[] bytes = new byte[8];

                reader.Read(bytes, (int)Position , 8);
                return bytes;
            }

        }
       

    }
}
