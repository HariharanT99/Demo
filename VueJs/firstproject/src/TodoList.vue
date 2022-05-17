<template>
  Hello From Vue
  <div class="row justify-content-center">
    <div class="col-6">
      <NewTask @addTask="(task) => onAddTask(task)"></NewTask>
    </div>

  </div>
  <TaskList :tasks="tasks"></TaskList>
</template>

<script>
import NewTask from "./components/NewTask.vue";
import TaskList from "./components/TaskList.vue";
export default {
  data() {
    return {
      tasks: [],
    };
  },
  methods: {
    onAddTask(task) {
      console.log("Hey", task.name);
      this.tasks.push({ name: task.name, pending: task.pending || true });
      console.log(this.tasks);
    },
  },
  components: { NewTask, TaskList },
};
</script>
