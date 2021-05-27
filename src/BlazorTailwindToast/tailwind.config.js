module.exports = {
  purge: {
    enabled: true,
    content: [
      './**/*.html',
      './**/*.razor',
      './**/*.cs'
    ],
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [],
}