export const environment = {
  production: false,
  hmr: false,
  application: {
    name: 'Base',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44305',
    clientId: 'Base_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'Base',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44305',
    },
  },
  localization: {
    defaultResourceName: 'Base',
  },
};
