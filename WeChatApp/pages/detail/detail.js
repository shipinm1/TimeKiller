Page({
  data: {
  },
  onLoad: function (option) {
    console.log(option.passing)
    this.setData({name:option.passing})
  }
})