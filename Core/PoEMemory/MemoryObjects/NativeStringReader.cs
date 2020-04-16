using ExileCore.Shared.Interfaces;

namespace ExileCore.PoEMemory.MemoryObjects
{
    public class NativeStringReader
    {
        public static string ReadString(long address, IMemory M)
        {
            var Size = M.Read<int>(address + 0x10);
            var Capacity = M.Read<int>(address + 0x18);

            if(Size < 0)
            {
                return string.Empty;
            }
            //var size = Size;
            //if (size == 0)
            //    return string.Empty;
            if ( /*8 <= size ||*/ 8 <= Capacity) //Have no idea how to deal with this
            {
                var readAddr = M.Read<long>(address);
                var output = M.ReadStringU(readAddr, Size * 2, false);
                return output.Length > Size ? output.Substring(0, Size) : output;
            }

            return M.ReadStringU(address);
        }
    }
}
