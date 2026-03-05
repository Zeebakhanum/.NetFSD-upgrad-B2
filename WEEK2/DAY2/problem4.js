// Task Manager with Async Storage (LEVEL-2)

// -----------------------------
// In-memory storage
// -----------------------------
let tasks = [];

// ======================================================
// 1️⃣ CALLBACK VERSION
// ======================================================

const addTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasks.push(task);
    callback(`✅ Task added (Callback): ${task}`);
  }, 1000);
};

const listTasksCallback = (callback) => {
  setTimeout(() => {
    callback(`📋 Tasks (Callback):\n${tasks.join("\n")}`);
  }, 1000);
};

// ======================================================
// 2️⃣ PROMISE VERSION
// ======================================================

const addTaskPromise = (task) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks.push(task);
      resolve(`✅ Task added (Promise): ${task}`);
    }, 1000);
  });
};

const deleteTaskPromise = (task) => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const index = tasks.indexOf(task);
      if (index !== -1) {
        tasks.splice(index, 1);
        resolve(`🗑 Task deleted (Promise): ${task}`);
      } else {
        reject(`❌ Task not found: ${task}`);
      }
    }, 1000);
  });
};

const listTasksPromise = () => {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(`📋 Tasks (Promise):\n${tasks.join("\n")}`);
    }, 1000);
  });
};

// ======================================================
// 3️⃣ ASYNC / AWAIT VERSION
// ======================================================

const runAsyncVersion = async () => {
  try {
    console.log("\n--- Async/Await Version ---");

    const add1 = await addTaskPromise("Learn JavaScript");
    console.log(add1);

    const add2 = await addTaskPromise("Practice Async");
    console.log(add2);

    const list1 = await listTasksPromise();
    console.log(list1);

    const del = await deleteTaskPromise("Learn JavaScript");
    console.log(del);

    const list2 = await listTasksPromise();
    console.log(list2);

  } catch (error) {
    console.error(error);
  }
};

// ======================================================
// Execute All Versions
// ======================================================

// Callback Demo
addTaskCallback("Task 1", (message) => {
  console.log(message);

  listTasksCallback((list) => {
    console.log(list);
  });
});

// Run Async/Await after small delay
setTimeout(() => {
  runAsyncVersion();
}, 3000);