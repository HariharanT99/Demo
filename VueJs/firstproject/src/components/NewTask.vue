<template>
  <div class="input-group mb-3">
    <input
      type="text"
      class="form-control"
      placeholder="Username"
      aria-label="Username"
      aria-describedby="basic-addon1"
      v-model="name"
    />
    <span class="input-group-text" @click="add" id="basic-addon1">+</span>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: "",
    };
  },
  methods: {
    add() {
      this.$emit('addTask', {name: this.name });
      this.name = "";
    },
  },
};
</script>
