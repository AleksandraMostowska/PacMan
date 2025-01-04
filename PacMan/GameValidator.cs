using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PacMan;

public static class GameValidator
{
    public static int Limiter(int value, int min, int max) => value < min ? min : value > max ? max : value;

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();

        if (value.Length > max) value = value[..max].Trim();

        if (value.Length < min) value = value.PadRight(min, placeholder);

        if (char.IsLower(value[0])) value = char.ToUpper(value[0]) + value[1..];

        return value;
    }
}
