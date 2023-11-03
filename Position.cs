using System;
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

    public void Deconstruct(out int row, out int column)
    {
        row = Row;
        column = Column;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Position position) return false;

        return this.Row.Equals(position.Row) && this.Column.Equals(position.Column);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + Row.GetHashCode();
            hash = hash * 31 + Column.GetHashCode();
            return hash;
        }
    }

    public override string ToString()
    {
        return $"{nameof(Position)} = {{{Row}, {Column}}}";
    }

    public int CompareTo(Position? other)
    {
        if (other is null) return 1;

        // int thisSize = Row + Column;
        // int otherSize = other.Row + other.Column;

        // return thisSize.CompareTo(otherSize);
        return Row.CompareTo(other.Row) + Column.CompareTo(other.Column);
    }

    public Position Copy() => new(Row, Column);

    public static Position operator +(Position left, Position right) => new(left.Row + right.Row, left.Column + right.Column);
    public static Position operator -(Position left, Position right) => new(left.Row - right.Row, left.Column - right.Column);

    public static bool operator ==(Position left, Position right) => left.Row == right.Row && left.Column == right.Column;
    public static bool operator !=(Position left, Position right) => left.Row != right.Row && left.Column != right.Column;
}

