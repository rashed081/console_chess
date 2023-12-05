using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public interface IPiece
    {
        public abstract Cell nextValidMoves();
        public abstract Cell attackCells();
        public abstract Cell captureFreeMoves();

        public abstract Cell pieceAt();

    }
}
