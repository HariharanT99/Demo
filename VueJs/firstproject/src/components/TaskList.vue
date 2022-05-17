<template>
  <div class="row justify-content-center">
    <div class="col-8 card">
      <ul class="list-group list-group-flush">
        <li
          class="list-group-item"
          v-if="tasks.length > 0"
          v-bind:class="taskStatus(i)"
          v-for="(task, i) in tasks"
        >
          {{ task.name }}
          <span class="float-end hover-cursor" @click="onDone(i)">X</span>
        </li>
        <li class="list-group-item" v-else>There is no task for today</li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    tasks: {
      type: Array,
      required: true,
    },
  },
  methods: {
    taskStatus(i) {
      return {
        pending: this.tasks[i].pending,
        "text-decoration-line-through": !this.tasks[i].pending,
      };
    },
    onDone(i) {
      console.log(i);
      this.tasks[i].pending = !this.tasks[i].pending;
      console.log("on done", this.tasks);
    },
  },
};
</script>

<style>
.done {
  text-decoration: line-through;
}

.hover-cursor {
  cursor: pointer;
}
</style>
