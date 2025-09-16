public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];
        byte prefix;
        byte[] payload;

        if (reading >= 0)
        {
            if (reading <= ushort.MaxValue)
            {
                payload = BitConverter.GetBytes((ushort)reading);
                prefix = 2;
            }
            else if (reading <= Int32.MaxValue)
            {
                payload = BitConverter.GetBytes((int)reading);
                prefix = (byte)(256 - 4);
            }
            else if (reading <= UInt32.MaxValue)
            {
                payload = BitConverter.GetBytes((uint)reading);
                prefix = 4;
            }
            else
            {
                payload = BitConverter.GetBytes((long)reading);
                prefix = (byte)(256 - 8);
            }
        }
        else
        {
            if (reading >= Int16.MinValue)
            {
                payload = BitConverter.GetBytes((short)reading);
                prefix = (byte)(256 - 2);
            }
            else if (reading >= Int32.MinValue)
            {
                payload = BitConverter.GetBytes((int)reading);
                prefix = (byte)(256 - 4);
            }
            else
            {
                payload = BitConverter.GetBytes((long)reading);
                prefix = (byte)(256 - 8);
            }
        }

        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 2) return 0;

        byte prefix = buffer[0];

        int size;
        bool signed;
        if (prefix == 2 || prefix == 4 || prefix == 8)
        {
            signed = false;
            size = prefix;
        }
        else if (prefix == 254 || prefix == 252 || prefix == 248)
        {
            signed = true;
            size = 256 - prefix;
        }
        else
        {
            return 0;
        }

        if (buffer.Length < 1 + size) return 0;

        var payload = new byte[size];
        Array.Copy(buffer, 1, payload, 0, size);

        if (signed)
        {
            return size switch
            {
                2 => BitConverter.ToInt16(payload, 0),
                4 => BitConverter.ToInt32(payload, 0),
                8 => BitConverter.ToInt64(payload, 0),
                _ => 0
            };
        }
        else
        {
            return size switch
            {
                2 => BitConverter.ToUInt16(payload, 0),
                4 => BitConverter.ToUInt32(payload, 0),
                _ => 0
            };
        }
    }
}
