﻿// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.CosmosRepository
{
    /// <summary>
    /// This is the repository interface for any implementation of 
    /// <typeparamref name="TItem"/>, exposing asynchronous C.R.U.D. functionality.
    /// </summary>
    /// <typeparam name="TItem">The <see cref="Item"/> subclass type.</typeparam>
    /// <example>
    /// With DI, use .ctor injection to require any subclass of <see cref="Item"/>:
    /// <code language="c#">
    /// <![CDATA[
    /// public class ConsumingService
    /// {
    ///     readonly IRepository<SomePoco> _pocoRepository;
    ///     
    ///     public ConsumingService(IRepository<SomePoco> pocoRepository) =>
    ///         _pocoRepository = pocoRepository;
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public interface IRepository<TItem> where TItem : Item
    {
        /// <summary>
        /// Gets the <see cref="Item"/> subclass instance as a <typeparamref name="TItem"/> that corresponds to the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The string identifier.</param>
        /// <returns>A <see cref="ValueTask{TItem}"/> representing the <see cref="Item"/> subclass instance as a <typeparamref name="TItem"/>.</returns>
        ValueTask<TItem> GetAsync(string id);

        /// <summary>
        /// Gets an <see cref="IEnumerable{TItem}"/> collection of <see cref="Item"/> 
        /// subclasses that match the given <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The expression used for evaluating a matching item.</param>
        /// <returns>A collection of item instances who meet the <paramref name="predicate"/> condition.</returns>
        ValueTask<IEnumerable<TItem>> GetAsync(Expression<Func<TItem, bool>> predicate);

        /// <summary>
        /// Creates a cosmos item representing the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The item value to create.</param>
        /// <returns>A <see cref="ValueTask{TItem}"/> representing the <see cref="Item"/> subclass instance as a <typeparamref name="TItem"/>.</returns>
        ValueTask<TItem> CreateAsync(TItem value);

        /// <summary>
        /// Creates one or more cosmos item(s) representing the given <paramref name="values"/>. 
        /// </summary>
        /// <param name="values">The item values to create.</param>
        /// <returns>A <see cref="Task{TItem}"/></returns>
        Task<TItem[]> CreateAsync(IEnumerable<TItem> values);

        /// <summary>
        /// Updates the cosmos object that corresponds to the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The item value to update.</param>
        /// <returns>A <see cref="ValueTask{TItem}"/> representing the <see cref="Item"/> subclass instance as a <typeparamref name="TItem"/>.</returns>
        ValueTask<TItem> UpdateAsync(TItem value);

        /// <summary>
        /// Deletes the cosmos object that corresponds to the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The object to delete.</param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous delete operation.</returns>
        ValueTask DeleteAsync(TItem value);

        /// <summary>
        /// Deletes the cosmos object that corresponds to the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The string identifier.</param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous delete operation.</returns>
        ValueTask DeleteAsync(string id);
    }
}