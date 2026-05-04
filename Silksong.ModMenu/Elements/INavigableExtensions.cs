using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UI;

namespace Silksong.ModMenu.Elements;

/// <summary>
/// Helper functions for INavigable instances.
/// </summary>
public static class INavigableExtensions
{
    /// <summary>
    /// Helper functions for INavigable instances.
    /// </summary>
    extension(INavigable self)
    {
        /// <summary>
        /// Set the upwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborUp(Selectable selectable) =>
            self.SetNeighbor(NavigationDirection.Up, [selectable]);

        /// <summary>
        /// Set the upwards neighbor of this navigable to one of the given options.
        /// </summary>
        public void SetNeighborUp(IEnumerable<Selectable> selectables) =>
            self.SetNeighbor(NavigationDirection.Up, selectables);

        /// <summary>
        /// Set the upwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborUp(SelectableElement selectableElement)
        {
            if (selectableElement.GetSelectables(NavigationDirection.Up, out var selectables))
                self.SetNeighborDown(selectables);
        }

        /// <summary>
        /// Declare that this navigable has no upwards neighbor.
        /// </summary>
        public void ClearNeighborUp() => self.ClearNeighbor(NavigationDirection.Up);

        /// <summary>
        /// Get the most eligible selectables within this navigable when navigating upwards into it.
        /// </summary>
        public bool GetNeighborsUp(
            [MaybeNullWhen(false)] out IEnumerable<Selectable> selectables
        ) => self.GetSelectables(NavigationDirection.Up, out selectables);

        /// <summary>
        /// Set the leftwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborLeft(Selectable selectable) =>
            self.SetNeighbor(NavigationDirection.Left, [selectable]);

        /// <summary>
        /// Set the leftwards neighbor of this navigable to one of the given options.
        /// </summary>
        public void SetNeighborLeft(IEnumerable<Selectable> selectables) =>
            self.SetNeighbor(NavigationDirection.Left, selectables);

        /// <summary>
        /// Set the leftwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborLeft(SelectableElement selectableElement)
        {
            if (selectableElement.GetSelectables(NavigationDirection.Left, out var selectables))
                self.SetNeighborDown(selectables);
        }

        /// <summary>
        /// Declare that this navigable has no upwards neighbor.
        /// </summary>
        public void ClearNeighborLeft() => self.ClearNeighbor(NavigationDirection.Left);

        /// <summary>
        /// Get the most eligible selectables within this navigable when navigating leftwards into it.
        /// </summary>
        public bool GetNeighborsLeft(
            [MaybeNullWhen(false)] out IEnumerable<Selectable> selectable
        ) => self.GetSelectables(NavigationDirection.Left, out selectable);

        /// <summary>
        /// Set the rightwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborRight(Selectable selectable) =>
            self.SetNeighbor(NavigationDirection.Right, [selectable]);

        /// <summary>
        /// Set the rightwards neighbor of this navigable to one of the given options.
        /// </summary>
        public void SetNeighborRight(IEnumerable<Selectable> selectables) =>
            self.SetNeighbor(NavigationDirection.Right, selectables);

        /// <summary>
        /// Set the rightwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborRight(SelectableElement selectableElement)
        {
            if (selectableElement.GetSelectables(NavigationDirection.Right, out var selectables))
                self.SetNeighborDown(selectables);
        }

        /// <summary>
        /// Get the most eligible selectables within this navigable when navigating rightwards into it.
        /// </summary>
        public bool GetNeighborsRight(
            [MaybeNullWhen(false)] out IEnumerable<Selectable> selectables
        ) => self.GetSelectables(NavigationDirection.Right, out selectables);

        /// <summary>
        /// Declare that this navigable has no upwards neighbor.
        /// </summary>
        public void ClearNeighborRight() => self.ClearNeighbor(NavigationDirection.Right);

        /// <summary>
        /// Set the downwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborDown(Selectable selectable) =>
            self.SetNeighbor(NavigationDirection.Down, [selectable]);

        /// <summary>
        /// Set the downwards neighbor of this navigable to one of the given options.
        /// </summary>
        public void SetNeighborDown(IEnumerable<Selectable> selectables) =>
            self.SetNeighbor(NavigationDirection.Down, selectables);

        /// <summary>
        /// Set the downwards neighbor of this navigable.
        /// </summary>
        public void SetNeighborDown(SelectableElement selectableElement)
        {
            if (selectableElement.GetSelectables(NavigationDirection.Down, out var selectables))
                self.SetNeighborDown(selectables);
        }

        /// <summary>
        /// Declare that this navigable has no upwards neighbor.
        /// </summary>
        public void ClearNeighborDown() => self.ClearNeighbor(NavigationDirection.Down);

        /// <summary>
        /// Get the most eligible selectables within this navigable when navigating downwards into it.
        /// </summary>
        public bool GetNeighborsDown(
            [MaybeNullWhen(false)] out IEnumerable<Selectable> selectables
        ) => self.GetSelectables(NavigationDirection.Down, out selectables);

        /// <summary>
        /// Symmetrically connect two INavigables.
        /// </summary>
        public void ConnectSymmetric(INavigable dest, NavigationDirection direction)
        {
            if (dest.GetSelectables(direction, out var s))
                self.SetNeighbor(direction, s);
            if (self.GetSelectables(direction.Opposite(), out s))
                dest.SetNeighbor(direction.Opposite(), s);
        }
    }
}
