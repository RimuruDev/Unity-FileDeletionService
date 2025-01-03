# FileDeletionService

A robust and reusable service for managing file deletions in Unity projects. This service supports both immediate and delayed file deletions and is designed to work seamlessly in Unity's runtime environment, including on Android and other platforms.

## Features
- **Immediate File Deletion**: Delete files instantly.
- **Delayed File Deletion**: Schedule file deletions with customizable delays.
- **Batch File Deletion**: Delete multiple files at once, either immediately or with a delay.
- **Singleton Design**: Ensures a single instance of the service is accessible globally.
- **Persistent Object**: The service persists across scene loads, ensuring its availability throughout the game lifecycle.

## Dependencies
### Required Components
1. [**MonoSingleton**](https://github.com/RimuruDev/MonoSingleton): A generic singleton implementation for Unity components.
2. **ImmortalGameObject**: Ensures the game object persists across scenes.

```csharp
namespace AbyssMoth.Internal.Codebase.Runtime.Common.Components
{
    [DisallowMultipleComponent]
    public sealed class ImmortalGameObject : MonoBehaviour
    {
        [SerializeField] private bool setParentNull = true;

        private void Awake()
        {
            if (setParentNull)
                transform.SetParent(null);

            DontDestroyOnLoad(gameObject);
        }
    }
}
```

3. [**WaitForSecondsCache**](https://github.com/RimuruDev/Unity-WaitForSecondsCache): A utility for reusing `WaitForSeconds` objects to optimize coroutines.

## Usage

### Setup
1. Attach the `FileDeletionService` to a GameObject or let it initialize automatically as a singleton.
2. The service requires no manual configuration and will persist across scenes.

### Examples

#### Immediate File Deletion
```csharp
FileDeletionService.Instance.DeleteFileImmediately("/path/to/file.json");
```

#### Delayed File Deletion
```csharp
FileDeletionService.Instance.DeleteFileWithDelay("/path/to/file.json", 5f); // Delete after 5 seconds
```

#### Batch File Deletion with Delay
```csharp
string[] filesToDelete = {
    "/path/to/file1.json",
    "/path/to/file2.json"
};
FileDeletionService.Instance.DeleteMultipleFilesWithDelay(filesToDelete, 10f); // Delete after 10 seconds
```

## Implementation

The `FileDeletionService` is implemented as a singleton using the [MonoSingleton](https://github.com/RimuruDev/MonoSingleton) pattern. It ensures global accessibility and persistence across scenes.

### Notes
- **Performance Optimization**: Using `WaitForSecondsCache` reduces memory allocations in coroutines.
- **Error Handling**: All file operations are wrapped in try-catch blocks to prevent crashes due to file system errors.
- **Singleton Access**: Ensure you use `FileDeletionService.Instance` to access the service.

## License
This project is part of the *Murder Drones Endless Way 2D* and is licensed under the copyright of **RimuruDev aka AbyssMothGames**. For any inquiries, contact:
- **Email**: rimuru.dev@gmail.com
- **GitHub**: [RimuruDev](https://github.com/RimuruDev)
- **LinkedIn**: [Profile](https://www.linkedin.com/in/rimuru/)

