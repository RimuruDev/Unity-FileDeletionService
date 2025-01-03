// ReSharper disable CheckNamespace
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeMadeStatic.Global

using System;
using System.IO;
using UnityEngine;
using System.Collections;
using AbyssMoth.Internal.Codebase.Runtime.Common.Components;

namespace AbyssMoth
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ImmortalGameObject))]
    public sealed class FileDeletionService : MonoSingleton<FileDeletionService>
    {
        /// <summary>
        /// Удалить файл немедленно.
        /// </summary>
        public void DeleteFileImmediately(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Debug.Log($"File deleted: {filePath}");
                }
                else
                {
                    Debug.LogWarning($"File not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to delete file: {filePath}\n{ex.Message}");
            }
        }

        /// <summary>
        /// Удалить файл с задержкой.
        /// </summary>
        public void DeleteFileWithDelay(string filePath, float delayInSeconds) =>
            StartCoroutine(DeleteFileCoroutine(filePath, delayInSeconds));

        /// <summary>
        /// Удалить файл в корутине с задержкой.
        /// </summary>
        private IEnumerator DeleteFileCoroutine(string filePath, float delayInSeconds)
        {
            yield return WaitForSecondsCache.Get(delayInSeconds);

            DeleteFileImmediately(filePath);
        }

        /// <summary>
        /// Удалить список файлов с задержкой.
        /// </summary>
        public void DeleteMultipleFilesWithDelay(string[] filePaths, float delayInSeconds) =>
            StartCoroutine(DeleteMultipleFilesCoroutine(filePaths, delayInSeconds));

        /// <summary>
        /// Удалить список файлов в корутине с задержкой.
        /// </summary>
        private IEnumerator DeleteMultipleFilesCoroutine(string[] filePaths, float delayInSeconds)
        {
            yield return WaitForSecondsCache.Get(delayInSeconds);

            foreach (var filePath in filePaths)
                DeleteFileImmediately(filePath);
        }
    }
}
