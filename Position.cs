﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal class Position : IComparable<Position>
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Position position) return false;

        return Row.Equals(position.Row) && Column.Equals(position.Column);
    }

    public int CompareTo(Position? other)
    {
        if (other is null) return 1;

        if (Row.CompareTo(other.Row) != 0) return Row.CompareTo(other.Row);

        else return Column.CompareTo(other.Column);
    }

    public Position Copy() => new(Row, Column);

    public static Position operator +(Position left, Position right) => new(left.Row + right.Row, left.Column + right.Column);
    public static Position operator -(Position left, Position right) => new(left.Row - right.Row, left.Column - right.Column);

    public static bool operator ==(Position left, Position right) => left.Row == right.Row && left.Column == right.Column;
    public static bool operator !=(Position left, Position right) => left.Row != right.Row && left.Column != right.Column;

    public override int GetHashCode() => HashCode.Combine(Row, Column);

    public override string ToString() => $"{nameof(Position)} = {{{Row}, {Column}}}";

}

